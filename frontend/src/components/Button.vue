<template>
  <button>
    {{props.value}}
  </button>
</template>

<script setup lang="ts">
interface Props {
  value: {
    type: string,
    default: ''
  },
  backColor: {
    type: string,
    default: "orange"
  },
  textColor: {
    type: string,
    default: "white"
  },
  width: {
    type: string,
    required: true
  },
  height: {
    type: string,
    required: true
  }
}

const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
button {
  outline: none;
  background-color: v-bind(backColor);
  //border: none;
  height: v-bind('height');
  width: v-bind('width');
  border-radius: 7px;
  border: none;
  color: v-bind(textColor) !important;

  &:active {

  }

  &:hover {
    cursor: pointer;
    border: 1px solid white;
  }
}
</style>