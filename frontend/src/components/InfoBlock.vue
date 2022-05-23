<template>
  <div class="info-block__container">
    <div class="info-block__header">
      <h2>{{props.header}}</h2>
    </div>
    <div class="info-block__content">
      <slot></slot>
    </div>
  </div>
</template>

<script lang="ts" setup>
interface Props {
  header: {
    type: string,
    required: true
  }
}

const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
.info-block__container{
  display: flex;
  flex-direction: column;
  width: 100%;

  &__header{
    margin-bottom: 20px;
  }
}
</style>