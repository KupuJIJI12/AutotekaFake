<template>
  <div class="info-block__container">
    <div class="info-block__header">
      <div class="znak" ref="znak"></div>
      <h2>{{props.header}}</h2>
    </div>
    <div class="info-block__content">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { onBeforeMount, onMounted, onUpdated, ref } from "vue";

interface Props {
  header: {
    type: string,
    required: true
  },
  isStrength: undefined
}

const znak = ref(null);

onMounted(() => {
  if(props.isStrength !== undefined) {
    znak.value.style.backgroundColor = props.isStrength ? '#0af' : '#f65458'
  }
})

const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
:root{
  --znak-color: transparent;
}

.info-block__container{
  display: flex;
  flex-direction: column;
  width: 100%;

  .info-block__header{
    display: flex;
    flex-direction: row;
    align-items: center;
    position: relative;
    left: -30px;
  }

  .znak{
    border-radius: 50%;
    width: 12px;
    height: 12px;
    //background-color: var(--znak-color);
    margin-right: 15px;
  }
}
</style>