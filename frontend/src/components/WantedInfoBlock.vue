<template>
  <info-block header="Нет сведений о розыске" :is-strength="true">
    <div class="wanted-info-block__container">
      <span>Покупка разыскиваемого автомобиля грозит тем, что его отберут в ГИБДД при регистрации, и пока будет идти следствие, а это может затянуться на долгий срок, автомобиль будет стоять на штрафплощадке.
    </span>
    </div>
  </info-block>
</template>

<script>
import InfoBlock from "@/components/InfoBlock";

export default {
  name: "WantedInfoBlock",
  components: { InfoBlock }
};
</script>

<style scoped>

</style>