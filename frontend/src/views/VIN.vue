<template>
  <main class="wrp__main__container">
    <div class="wrp__main__cnt">
      <div class="wrp__main__cnt__auto-info-block">
        <h1>{{ title }}</h1>
        <vue-easy-lightbox
          scrollDisabled
          escDisabled
          moveDisabled
          :visible="lightboxVisible"
          :imgs="imgs"
          @hide="handleHide">
        </vue-easy-lightbox>
        <div class="auto-info-block_report">
          <label class="auto-info-block__report_label">Отчёт от <b>{{ reportDate }}</b></label>
          <div class="auto-info-block__report__actions">
            <Button
              value="Скачать"
              backColor="#ED7749"
              textColor="white"
              width="100px"
              height="30px">
            </Button>
          </div>
        </div>
        <div class="vehicle-picture-block" @click="handleHide">
          <img :src="preview" alt="Загрузка...">
          <div><b>1/2</b></div>
        </div>
        <spec-info-block :specifications="specifications"></spec-info-block>
        <restrict-info-block :restrictions="restrictions"></restrict-info-block>
        <wanted-info-block></wanted-info-block>
        <taxi-licenses-info-block></taxi-licenses-info-block>
        <owner-info-block :owners="owners"></owner-info-block>
        <crash-info-block :crashes="crashes"></crash-info-block>
        <fine-info-block :fines="fines"></fine-info-block>
        <inspect-info-block :inspects="inspects"></inspect-info-block>
        <line-chart class="chart-of-mileage" :data="chartData"></line-chart>
        <conclusion-info-block :conclusion="conclusion"></conclusion-info-block>
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { Restrict } from "@/models/Restrict";
import { Owner, OwnerType } from "@/models/Owner";
import OwnerInfoBlock from "@/components/OwnerInfoBlock.vue";
import SpecInfoBlock from "@/components/SpecInfoBlock.vue";
import RestrictInfoBlock from "@/components/RestrictInfoBlock.vue";
import Button from "@/components/Button.vue";
import CrashInfoBlock from "@/components/CrashInfoBlock.vue";
import { Crash } from "@/models/Crash";
import InspectInfoBlock from "@/components/InspectInfoBlock.vue";
import { Inspect } from "@/models/Inspect";
import LineChart from "@/lineChart";
import { formatDate } from "@/helpers/dateFormatter";
import { onBeforeMount, onMounted, ref } from "vue";
import VueEasyLightbox from "vue-easy-lightbox";
import WantedInfoBlock from "@/components/WantedInfoBlock.vue";
import TaxiLicensesInfoBlock from "@/components/TaxiLicensesInfoBlock.vue";
import FineInfoBlock from "@/components/FineInfoBlock.vue";
import ConclusionInfoBlock from "@/components/ConclusionInfoBlock.vue";

const report = ref({});
const reportDate = ref("");
const specifications = ref([]);
const restrictions = ref<Restrict[]>([]);
const owners = ref<Owner[]>([]);
const crashes = ref<Crash[]>([]);
const inspects = ref<Inspect[]>([]);
const chartData = ref({});
const lightboxVisible = ref(false);
const imgs = ref([]);
const preview = ref("");
const title = ref("");
const conclusion = ref({});
const fines = ref([]);

function handleHide() {
  lightboxVisible.value = !lightboxVisible.value;
}

function getOnlyDate(date: string | Date): string {
  return /.+г./.exec(formatDate(new Date(date)))[0];
}


onBeforeMount(async () => {
  const response = await fetch(`https://localhost:5001/api/Report?vin=${window.location.pathname.replace("/", "")}`, {
    method: "POST"
  });
  const id = await response.text();

  await fetch(`https://localhost:5001/api/Report/report?reportId=${id}`)
    .then(r => r.json())
    .then(data => report.value = data);

  console.log(report.value);

  const regexDateResult = /(.+г.),(.+):\d+$/.exec(formatDate(report.value.date));
  reportDate.value = regexDateResult[1] + regexDateResult[2];

  const car = report.value.car;
  title.value = `${report.value.car.model}, ${/^(\d+)-/.exec(report.value.car.passport.yearOfManufacture)[1]} года`;

  imgs.value = car.photos.reverse().map((p: { description: any; value: any; }) => ({
    title: p.description,
    src: "data:image/png;base64, " + p.value
  }));

  preview.value = imgs.value[0].src;

  specifications.value = [
    [
      {
        type: "VIN",
        value: car.vin
      },
      {
        type: "Госномер",
        value: car.carNumber
      },
      {
        type: "Номер двигателя",
        value: car.engine.engineNumber
      },
      {
        type: "Номер ПТС",
        value: car.passport.seriesAndNumberPassport
      },
      {
        type: "Номер Кузова",
        value: car.bodyNumber
      },
      {
        type: "Номер СТС",
        value: car.license.registrationNumber
      }
    ],
    [
      {
        type: "Год выпуска",
        value: /^\d+/.exec(car.passport.yearOfManufacture)[0]
      },
      {
        type: "Тип ТС",
        value: car.type
      },
      {
        type: "Цвет",
        value: car.color
      },
      {
        type: "Объём двигателя",
        value: `${car.engine.displacement} см³`
      },
      {
        type: "Мощность",
        value: `${car.engine.power} л.с.`
      },
      {
        type: "Последний пробег",
        value: car.lastMileage + " км."
      }
    ]
  ];

  car.carRestricts.forEach((r: { type: string; date: string | Date; organization: string; region: string; }) => restrictions.value.push({
    type: r.type,
    date: getOnlyDate(r.date),
    organization: r.organization,
    region: r.region
  }));

  car.passport.owners.forEach(o => {
    const duration = new Date(new Date(o.ownershipDuration) - new Date());
    owners.value.push({
      //todo
      ownershipPeriod: getOnlyDate(o.ownershipPeriod),
      ownershipDuration: `с ${getOnlyDate(o.ownershipPeriod)} по ${getOnlyDate(o.ownershipDuration)}`,
      type: o.ownerType === 0 ? "Физическое лицо" : "Юридическое лицо",
      regionRegistration: o.presentAddress,
      organisationName: o.ownerType !== 0 ? o.organizationName : null
    });
  });

  car.carCrashes.forEach(c => crashes.value.push({
    date: getOnlyDate(c.date),
    type: c.type,
    vehicleCondition: "Повреждено",
    damaged: c.vehicleDamages.map(d => ({
      type: d.type
    }))
  }));

  car.fines.forEach(f => fines.value.push({
    status: "Не оплачен",
    cost: f.cost,
    decisionNumber: f.decisionNumber,
    date: getOnlyDate(f.date),
    description: f.description
  }));

  car.carInspects.forEach(i => inspects.value.push({
    date: new Date(i.date),
    mileage: i.mileage,
    price: i.cost,
    region: i.region,
    organization: i.organization,
    isPlan: false
  }));

  car.carPlanInspects.forEach(i => inspects.value.push({
    date: new Date(i.date),
    mileage: i.mileage,
    price: i.cost,
    region: i.region,
    organization: i.organization,
    isPlan: true
  }));

  inspects.value = inspects.value.sort((a, b) => (a.date as Date).getTime() - (b.date as Date).getTime());
  inspects.value = inspects.value.map(i => {
    i.date = getOnlyDate(i.date);
    return i;
  });

  chartData.value = {
    labels: inspects.value.map(v => v.date),
    datasets: [
      {
        label: "История пробега автомобиля",
        backgroundColor: "#0af",
        data: inspects.value.map(v => v.mileage)
      }
    ]
  };

  conclusion.value = {
    advantages: [
      owners.value.length <= 3 ? "Мало владельцев" : undefined,
      "Не находится в розыске",
      "Не работало в такси"
    ].filter(a => !!a),
    disadvantages: [
      restrictions.value.length > 0 ? "Действующие ограничения" : undefined,
      crashes.value.length > 0 ? "ДТП" : undefined,
      owners.value.length > 3 ? "Много владельцев" : undefined,
      fines.value.length > 0 ? "Действующие штрафы" : undefined
    ].filter(d => !!d),
    other: [].filter(o => !!o)
  };
});

</script>

<style lang="scss" scoped>
.wrp__main__container {
  width: 100%;
  display: flex;
  justify-content: center;
  margin-bottom: 50px;

  .vehicle-picture-block {
    margin-bottom: 15px;

    &:hover {
      cursor: pointer;
    }

    img {
      width: 100%;
      height: 100%;
    }

    div {
      text-align: center;
      padding: 5px;
      background-color: #e9e9e9;
      margin-top: -5px;
    }
  }

  .wrp__main__cnt {
    margin-top: 35px;
    width: 100%;
    max-width: 750px;
  }

  .auto-info-block_report {
    display: flex;
    align-items: center;
    margin-bottom: 25px;

    :first-child {
      margin-right: 15px;
    }
  }

  .chart-of-mileage {
    margin-top: 35px;
  }
}
</style>