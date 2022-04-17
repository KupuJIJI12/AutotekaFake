<template>
  <main class="wrp__main__container">
    <div class="wrp__main__cnt">
      <div class="wrp__main__cnt__auto-info-block">
        <h1>Skoda Oktavia, 2014</h1>
        <div class="auto-info-block_report">
          <label class="auto-info-block__report_label">Отчёт от {{ reportDate }}</label>
          <div class="auto-info-block__report__actions">
            <Button
              value="Скачать"
              backColor="#ED7749"
              width="100px"
              height="30px">
            </Button>
          </div>
          <div class="auto-info-block__report_tech-spec">
            <div></div>
            <div></div>
          </div>
        </div>
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import Button from "@/components/Button.vue";

const reportDate = "1 июня 2019 года";
</script>

<style lang="scss" scoped>
.wrp__main__container {
  width: 100%;
  display: flex;
  justify-content: center;

  .wrp__main__cnt {
    margin-top: 35px;
    width: 100%;
    max-width: 950px;
    border: 1px solid red;
  }

  .auto-info-block_report{
    display: flex;
    align-items: center;
    margin-bottom: 25px;

    :first-child{
      margin-right: 15px;
    }
  }
}
</style>