<template>
  <info-block header="Дорожно транспортные происшествия">
    <list-info-blocks>
      <div class="crash-info-block__content info-block__content_item" v-for="(crash) in props.crashes" :key="crash">
        <p><b>{{ crash.date }}</b></p>
        <p>
          <span class="crash-info-block__content_type">Тип происшествия: </span>
          <span class="crash-info-block__content_value">{{ crash.type }}</span>
        </p>
        <p>
          <span class="crash-info-block__content_type">Состояние авто после ДТП: </span>
          <span class="crash-info-block__content_value">{{ crash.vehicleCondition }}</span>
        </p>
        <Button value="Подробнее"
                backColor="#e0e0e0"
                textColor="black"
                height="30px"
                width="100px"
        ></Button>
      </div>
    </list-info-blocks>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock"
import {defineProps} from "vue";
import {Crash} from "@/models/Crash";
import ListInfoBlocks from "@/components/ListInfoBlocks.vue";
import Button from "@/components/Button.vue";

interface Props {
  crashes: Crash[]
}

const props = defineProps<Props>()
</script>

<style scoped>

</style>