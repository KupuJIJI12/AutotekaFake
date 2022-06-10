<template>
  <main class="wrp__main">
    <Input class="wrp__main__input" placeholder="Введите VIN" ref="input"/>
    <Button
      class="wrp__main__button"
      value="Проверить"
      backColor="#ED7749"
      textColor="white"
      width="100px"
      height="50px"
      @click="checkVin">
    </Button>
  </main>
</template>

<script setup lang="ts">
import Input from "@/components/Input.vue";
import Button from "@/components/Button.vue";
import { useRouter } from "vue-router";
import { ref } from "vue";

const router = useRouter();
const input = ref(null);

/*function checkVin(): void{

}*/
</script>

<style lang="scss" scoped>

.wrp__main {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100%;
  //background-image: url("~@/assets/tracks-removebg.png");

  &__input {
    margin-right: 15px;
  }
}

</style>