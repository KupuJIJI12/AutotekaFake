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
  background-color: unset;
  //border: none;
  height: 50px;
  width: 100px;
  border-radius: 7px;
  border: none;
  color: white;

  &:active {

  }

  &:hover {
    cursor: pointer;
    border: 1px solid white;
  }
}
</style>