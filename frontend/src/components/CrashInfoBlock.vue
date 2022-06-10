<template>
  <info-block :is-strength="false" header="Дорожно транспортные происшествия">
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
                @click="modalHandler"
        ></Button>
        <modal v-if="isCloseModal" @closeModal="modalHandler" :header="`Дтп от ${crash.date}`">
          <div style="display: flex">
            <div style="margin-right: 80px">
              <p><b>Повреждения: </b></p>
              <p v-for="damage in crash.damaged" :key="damage">{{getDamageType(+damage.type)}}</p>
            </div>
            <div>
              <p><b>Состояние авто: </b></p>
              <p>{{crash.vehicleCondition}}</p>
              <p><b>Тип происшествия: </b></p>
              <p>{{crash.type}}</p>
            </div>
          </div>
        </modal>
      </div>
    </list-info-blocks>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock"
import { defineProps, ref } from "vue";
import {Crash} from "@/models/Crash";
import ListInfoBlocks from "@/components/ListInfoBlocks.vue";
import Button from "@/components/Button.vue";
import Modal from "@/components/Modal.vue"

interface Props {
  crashes: Crash[]
}

function modalHandler(){
  isCloseModal.value = !isCloseModal.value
}

function getDamageType(type: number){
  switch (type){
    case 1: return 'Капот';
    case 2: return 'Левая передняя дверь';
    case 3: return 'Левая задняя дверь';
    case 4: return 'Правая передняя дверь';
    case 5: return 'Правая задняя дверь';
    case 6: return 'Багажник';
    case 7: return 'Передний бампер';
    case 8: return 'Задний бампер';
  }
}

const isCloseModal = ref(false)
const props = defineProps<Props>()
</script>

<style lang="scss" scoped>
.crash-info-block__content_type{
  color: #858585;
}
</style>