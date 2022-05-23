<template>
  <info-block header="Технические характеристики">
    <div class="spec-info-block__container">
      <div v-for="spec in props.specifications" :key="spec" class="spec-info-block">
        <p v-for="s in spec" :key="s.type">
          <span class="spec-type_span">{{s.type}}: </span>
          <span class="spec-value_span">{{s.value}}</span>
        </p>
      </div>
    </div>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock";

interface Props {
  specifications: {
    required: true,
    type: []
  }
}

const props = defineProps<Props>()
</script>

<style lang="scss" scoped>
.spec-info-block__container{
  width: 100%;
  display: flex;

  &:first-child .spec-info-block{
    margin-right: 25px;

    .spec-type_span{
      color: #858585;
    }
  }
}
</style>