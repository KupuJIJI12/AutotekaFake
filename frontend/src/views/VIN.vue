<template>
  <main class="wrp__main__container">
    <div class="wrp__main__cnt">
      <div class="wrp__main__cnt__auto-info-block">
        <h1>Четырка, 999999999999999 года</h1>
        <img src="" alt="">
        <div class="auto-info-block_report">
          <label class="auto-info-block__report_label">Отчёт от {{ reportDate }}</label>
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

const reportDate = "1 июня 2019 года";
const specifications = [
  [
    {
      type: 'VIN',
      value: 'XW8AN2XXXFXXXXXXX'
    },
    {
      type: 'Госномер',
      value: 'Х000ХХ777'
    },
    {
      type: 'Номер двигателя',
      value: '08XXX4A'
    },
    {
      type: 'Номер ПТС',
      value: '78УС60XXXX'
    }
  ],
  [
    {
      type: 'Год выпуска',
      value: '2014'
    },
    {
      type: 'Тип ТС',
      value: 'Легковая'
    },
    {
      type: 'Цвет',
      value: 'Белый'
    },
    {
      type: 'Объём двигателя',
      value: '1 598 см^3'
    }
  ]
]
const restrictions: Restrict[] = [
  {
    type: 'Запрет на регистрационные действия',
    date: '10 октября 2018 года',
    organization: 'Судебный пристав',
    region: 'Москва'
  }
]
const owners: Owner[] = [
  {
    ownershipPeriod: new Date(),
    ownershipDuration: new Date(),
    type: OwnerType.NaturalPerson,
    regionRegistration: 'Samara'
  },
]
const crashes: Crash[] = [
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
]
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

  .auto-info-block_report{
    display: flex;
    align-items: center;
    margin-bottom: 25px;

    :first-child{
      margin-right: 15px;
    }
  }
}
</style>