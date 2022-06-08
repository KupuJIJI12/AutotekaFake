<template>
  <main class="wrp__main__container">
    <div class="wrp__main__cnt">
      <div class="wrp__main__cnt__auto-info-block">
        <h1>Четырка, 999999999999999 года</h1>
        <img src="" alt="">
        <div class="auto-info-block_report">
          <label class="auto-info-block__report_label">Отчёт от <b>{{ reportDate }}</b></label>
          <div class="auto-info-block__report__actions">
            <Button
                value="Скачать"
                backColor="#0af"
                textColor="white"
                width="100px"
                height="30px">
            </Button>
          </div>
        </div>
        <spec-info-block :specifications="specifications"></spec-info-block>
        <restrict-info-block :restrictions="restrictions"></restrict-info-block>
        <owner-info-block :owners="owners"></owner-info-block>
        <crash-info-block :crashes="crashes"></crash-info-block>
        <inspect-info-block :inspects="inspects"></inspect-info-block>
        <line-chart class="chart-of-mileage" :data="chartData"></line-chart>
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import {Restrict} from "@/models/Restrict";
import {Owner, OwnerType} from "@/models/Owner";
import OwnerInfoBlock from "@/components/OwnerInfoBlock.vue";
import SpecInfoBlock from "@/components/SpecInfoBlock.vue";
import RestrictInfoBlock from "@/components/RestrictInfoBlock.vue";
import Button from "@/components/Button.vue";
import CrashInfoBlock from "@/components/CrashInfoBlock.vue";
import {Crash} from "@/models/Crash";
import InspectInfoBlock from "@/components/InspectInfoBlock.vue";
import {Inspect} from "@/models/Inspect";
import LineChart from "@/lineChart";
import {formatDate} from "@/helpers/dateFormatter";
import {onBeforeMount, ref} from "vue";

const report = ref({});
const reportDate = ref('');
const specifications = ref([])
const restrictions = ref<Restrict[]>([])
const owners = ref<Owner[]>([])
const crashes = ref<Crash[]>([])
const inspects = ref<Inspect[]>([])
const chartData = ref({});

onBeforeMount(async () => {
  await fetch(`https://localhost:5001/api/Report`)
      .then(r => r.json())
      .then(data => report.value = data[0]);

  console.log(report.value)
  //todo
  reportDate.value = formatDate(report.value.date);
  const car = report.value.car;

  specifications.value = [
    [
      {
        type: 'VIN',
        value: car.vin
      },
      {
        type: 'Госномер',
        value: car.carNumber
      },
      {
        type: 'Номер двигателя',
        value: car.engine.engineNumber
      },
      {
        type: 'Номер ПТС',
        value: car.passport.seriesAndNumberPassport
      },
      {
        type: 'Номер Кузова',
        value: '78УС60XXXX'
      },
      {
        type: 'Номер СТС',
        value: car.license.registrationNumber
      }
    ],
    [
      {
        type: 'Год выпуска',
        value: /^\d+/.exec(car.passport.yearOfManufacture)[0]
      },
      {
        type: 'Тип ТС',
        value: 'Легковая'
      },
      {
        type: 'Цвет',
        value: car.color
      },
      {
        type: 'Объём двигателя',
        value: `${car.engine.displacement} см³`
      },
      {
        type: 'Мощность',
        value: `${car.engine.power} л.с.`
      },
      {
        type: 'Последний пробег',
        value: '78 300 км'
      }
    ]
  ]

  car.carRestricts.forEach((r: { type: string; date: string | Date; organization: string; region: string; }) => restrictions.value.push({
    type: r.type,
    date: /.+г./.exec(formatDate(new Date(r.date)))[0],
    organization: r.organization,
    region: r.region
  }))

  car.passport.owners.forEach(o => owners.value.push({
    //todo
    ownershipPeriod: new Date(),
    ownershipDuration: new Date(),
    type: o.ownerType === 0 ? 'Физическое лицо' : 'Юридическое лицо',
    regionRegistration: o.presentAddress,
    organisationName: o.ownerType !== 0 ? o.organizationName : null
  }))

  car.carCrashes.forEach(c => crashes.value.push({
    date: /.+г./.exec(formatDate(new Date(c.date)))[0],
    type: c.type,
    vehicleCondition: 'Повреждено',
    damaged: c.vehicleDamages.map(d => ({
      type: d.type
    }))
  }))

  car.carInspects.forEach(i => inspects.value.push({
    date: new Date(i.date).toLocaleDateString("ru-Ru"),
    mileage: i.mileage,
    price: i.cost,
    region: i.region,
    organization: i.organization,
    isPlan: false
  }))

  car.carPlanInspects.forEach(i => inspects.value.push({
    date: new Date(i.date).toLocaleDateString("ru-Ru"),
    mileage: i.mileage,
    price: i.cost,
    region: i.region,
    organization: i.organization,
    isPlan: true
  }))

  inspects.value = inspects.value.sort((a, b) => Date.parse(a.date as string) - Date.parse(b.date as string))

  chartData.value = {
    labels: inspects.value.map(v => /\d+\.\d+$/.exec(v.date.toString())),
    datasets: [
      {
        label: "История пробега автомобиля",
        backgroundColor: "#0af",
        data: inspects.value.map(v => v.mileage)
      }
    ]
  };
})


/*const restrictions: Restrict[] = [
  {
    type: 'Запрет на регистрационные действия',
    date: '10 октября 2018 года',
    organization: 'Судебный пристав',
    region: 'Москва'
  }
]*/
/*const owners: Owner[] = [
  {
    ownershipPeriod: new Date(),
    ownershipDuration: new Date(),
    type: OwnerType.NaturalPerson,
    regionRegistration: 'Samara'
  },
]*/
/*const crashes: Crash[] = [
  {
    date: new Date(),
    type: "Столкновение",
    vehicleCondition: 'Повреждено',
    damaged: [
      {
        type: "Столкновение",
        region: 'Москва'
      }
    ]
  },
  {
    date: new Date(),
    type: "Столкновение",
    vehicleCondition: 'Повреждено',
    damaged: [
      {
        type: "Столкновение",
        region: 'Москва'
      }
    ]
  },
  {
    date: new Date(),
    type: "Столкновение",
    vehicleCondition: 'Повреждено',
    damaged: [
      {
        type: "Столкновение",
        region: 'Москва'
      }
    ]
  }
]*/
/*const inspects: Inspect[] = [
  {
    date: new Date(2019, 3).toLocaleDateString("ru-Ru"),
    mileage: 1000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
  {
    date: new Date(2020, 1).toLocaleDateString("ru-Ru"),
    mileage: 15000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
  {
    date: new Date(2021, 6).toLocaleDateString("ru-Ru"),
    mileage: 45000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
  {
    date: new Date(2021, 8).toLocaleDateString("ru-Ru"),
    mileage: 60000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
  {
    date: new Date(2022, 5).toLocaleDateString("ru-Ru"),
    mileage: 45000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
  {
    date: new Date(2022, 12).toLocaleDateString("ru-Ru"),
    mileage: 83000,
    price: 10000,
    region: 'Samara',
    organization: 'Takaya',
    isPlan: false
  },
]*/


</script>

<style lang="scss" scoped>
.wrp__main__container {
  width: 100%;
  display: flex;
  justify-content: center;
  margin-bottom: 50px;

  .wrp__main__cnt {
    margin-top: 35px;
    width: 100%;
    max-width: 650px;
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