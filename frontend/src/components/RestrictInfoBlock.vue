<template>
  <info-block :is-strength="false" header="Ограничения">
    <div class="restrict-info-block__container">
      <p>Запрет регистрационных действий на машину накладывается, если у автовладельца есть неоплаченные штрафы и налоги, либо если имущество стало предметом спора.</p>
      <div class="restrict-info-block__content" v-for="restrict in props.restrictions" :key="restrict.date">
        <p>
          <span class="restrict-type-date">{{restrict.date}}</span>
        </p>
        <p>
          <span class="restrict-type">Вид ограничения: </span>
          <span class="restrict-value">{{restrict.type}}</span>
        </p>
        <p>
          <span class="restrict-type">Организация: </span>
          <span class="restrict-value">{{restrict.organization}}</span>
        </p>
        <p>
          <span class="restrict-type">Регион: </span>
          <span class="restrict-value">{{restrict.region}}</span>
        </p>
      </div>
    </div>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock";
import {Restrict} from "@/models/Restrict";

interface Props {
  restrictions: {
    required: true,
    type: Restrict[]
  }
}

const props = defineProps<Props>()
</script>

<style lang="scss" scoped>
.restrict-info-block__container{

  .restrict-info-block__content{
    .restrict-type-date{
      margin-bottom: 10px;
      font-weight: bold;
    }

    .restrict-type{
      color: #858585;
    }
  }
}

</style>