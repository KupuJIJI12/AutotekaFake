<template>
  <info-block header="История обслуживания у  дилера и СТО">
    <list-info-blocks>
      <div class="inspect-info-block__content info-block__content_item" v-for="(inspect) in props.inspects" :key="inspect">
        <div class="inspect-info-block__content_aside">
          <p>
            <span class="inspect-info-block__content_type">Дата: </span>
            <span class="inspect-info-block__content_value">{{ inspect.date }}</span>
          </p>
          <p>
            <span class="inspect-info-block__content_type">Пробег: </span>
            <span class="inspect-info-block__content_value">{{ inspect.mileage }}</span>
          </p>
          <p>
            <span class="inspect-info-block__content_type">Стоимость: </span>
            <span class="inspect-info-block__content_value">{{ inspect.price }}</span>
          </p>
        </div>
        <div class="inspect-info-block__content_aside">
          <p>
            <span class="inspect-info-block__content_type">Регион/Город: </span>
            <span class="inspect-info-block__content_value">{{ inspect.region }}</span>
          </p>
          <p>
            <span class="inspect-info-block__content_type">Организация: </span>
            <span class="inspect-info-block__content_value">{{ inspect.organization }}</span>
          </p>
          <p>
            <span class="inspect-info-block__content_type">Плановый: </span>
            <span class="inspect-info-block__content_value">{{ inspect.isPlan ? 'Да' : 'Нет'}}</span>
          </p>
        </div>
      </div>
    </list-info-blocks>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock"
import {defineProps} from "vue";
import ListInfoBlocks from "@/components/ListInfoBlocks.vue";
//import Button from "@/components/Button.vue";
import { Inspect } from "@/models/Inspect";

interface Props {
  inspects: Inspect[]
}

const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
.inspect-info-block__content{
  display: flex;
  justify-content: space-between;

  .inspect-info-block__content_type{
    color: #858585;
  }
}
</style>