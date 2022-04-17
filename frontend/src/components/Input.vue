<template>
  <input type="text" v-model="value" :placeholder="props.placeholder"/>
</template>

<script setup lang="ts">
import { ref } from "vue";

interface Props {
  placeholder: string;
}

const value = ref<string>("");
const props = defineProps<Props>();
</script>

<style lang="scss" scoped>
input {
  outline: none;
  border-radius: 7px;
  background-color: unset;
  border: 1px solid white;
  color: white;
  height: 45px;
  width: 500px;
  padding-left: 10px;

  &::placeholder{
    color: whitesmoke;

  }

  &:focus::placeholder{
    color: transparent;
  }
}
</style>