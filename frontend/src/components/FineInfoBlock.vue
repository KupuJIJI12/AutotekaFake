<template>
  <info-block :header="moreOneFine ? `${fines.length} неоплаченный штраф` : 'Нет действующих штрафов'" :is-strength="!moreOneFine">
    <div class="fine-info-block__container">
      <p>Показываем штрафы за правонарушения в области дорожного движения, совершенные с использованием проверяемого ТС по данным ГИС ГМП, МАДИ и АМПП.</p>
      <list-info-blocks>
        <div class="fine-info-block__content" v-for="fine in fines" :key="fine">
          <p><b>Штраф от {{fine.date}}</b></p>
          <p>
            <span class="fine-info-block__content_type">Статус: </span>
            <span class="fine-info-block__content_value">{{ fine.date }}</span>
          </p>
          <p>
            <span class="fine-info-block__content_type">Сумма: </span>
            <span class="fine-info-block__content_value">{{ fine.date }}</span>
          </p>
          <p>
            <span class="fine-info-block__content_type">Номер постановления: </span>
            <span class="fine-info-block__content_value">{{ fine.date }}</span>
          </p>
          <p>
            <span class="fine-info-block__content_type">Описание: </span>
            <span class="fine-info-block__content_value">{{ fine.date }}</span>
          </p>
        </div>
      </list-info-blocks>
    </div>
  </info-block>
</template>

<script>
import InfoBlock from "@/components/InfoBlock";
import ListInfoBlocks from "@/components/ListInfoBlocks";

export default {
  name: "FineInfoBlock",
  components: { ListInfoBlocks, InfoBlock },
  props: {
    fines: []
  },
  computed: {
    moreOneFine(){
      return this.fines.length > 0;
    }
  }
};
</script>

<style scoped>
.fine-info-block__content_type{
  color: #858585;
}
</style>