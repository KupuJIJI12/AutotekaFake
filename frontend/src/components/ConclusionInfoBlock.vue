<template>
  <info-block header="Итог" class="info-block">
    <div class="conclusion-info-block__container">
      <div class="conclusion-info-block_aside conclusion-info-block_aside-l">
        <ul>
          <p>Преимущества:</p>
          <li v-for="advantage in conclusion.advantages" :key="advantage">{{advantage}}</li>
        </ul>
      </div>
      <div class="conclusion-info-block_aside conclusion-info-block_aside-c">
        <ul>
          <p>Недостатки:</p>
          <li v-for="disadvantage in conclusion.disadvantages" :key="disadvantage">{{disadvantage}}</li>
        </ul>
      </div>
      <div class="conclusion-info-block_aside conclusion-info-block_aside-r">
        <ul>
          <p>Прочее:</p>
          <li v-for="other in conclusion.other" :key="other">{{other}}>></li>
        </ul>
      </div>
    </div>
  </info-block>
</template>

<script>
import InfoBlock from "@/components/InfoBlock";

export default {
  name: "ConclusionInfoBlock",
  components: { InfoBlock },
  props: {
    conclusion: {}
  },
  mounted() {
    console.log(this.conclusion)
  }
};
</script>

<style lang="scss" scoped>

.info-block{
  margin-top: 80px;

  .conclusion-info-block__container{
    border: 1px dotted #858585;
    border-radius: 10px;
    padding: 0 10px 10px 10px;
    background-color: #f8f8f8;
    display: flex;
    justify-content: space-between;
    min-height: 150px;

    .conclusion-info-block_aside{

      li{
        line-height: 2.5;
      }

      &-l{
        li{
          list-style-image: url("data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='10' height='10' viewBox='-2.2 -2.4 4 4'><circle r='1' stroke='rgb(0, 170, 255)' fill='rgb(0, 170, 255)' /></svg>");
        }
      }
      &-c{
        li{
          list-style-image: url("data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='10' height='10' viewBox='-2.2 -2.4 4 4'><circle r='1' stroke='rgb(246, 84, 88)' fill='rgb(246, 84, 88)' /></svg>");
        }
      }
      &-r{
        li{
          list-style-image: url("data:image/svg+xml;utf8,<svg xmlns='http://www.w3.org/2000/svg' width='10' height='10' viewBox='-2.2 -2.4 4 4'><circle r='1' stroke='rgb(133, 133, 133)' fill='rgb(133, 133, 133)' /></svg>");
        }
      }
    }
  }
}

</style>