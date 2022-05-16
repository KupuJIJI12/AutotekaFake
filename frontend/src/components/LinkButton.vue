<template>
  <button>
    {{ props.value }}
  </button>
</template>

<script setup lang="ts">
interface Props {
  value: {
    type: string,
    default: ""
  }
}

const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
button {
  outline: none;
  background-color: transparent;
  //border: none;
  height: 50px;
  width: 100px;
  border-radius: 7px;
  border: 1px solid #c7c7c7;
  color: #c7c7c7;

  &:active {

  }

  &:hover {
    cursor: pointer;
    border: 1px solid #01aaff;
    color: #01aaff !important;
  }
}
</style>