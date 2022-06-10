<template>
  <info-block :header="header" :is-strength="owners.length <= 2">
    <div class="owners-info-block__container">
      <div class="owners-info-block__content" v-for="(owner, i) in props.owners" :key="owner.ownershipPeriod">
        <p><b>{{i + 1}} владелец</b></p>
        <p class="owners-info-block__content_p">
          <span class="owners-info-block__content_span-type">Период владения: </span>
          <span class="owners-info-block__content_span-value">{{owner.ownershipPeriod}}</span>
        </p>
        <p class="owners-info-block__content_p">
          <span class="owners-info-block__content_span-type">Срок владения: </span>
          <span class="owners-info-block__content_span-value">{{owner.ownershipDuration}}</span>
        </p>
        <p class="owners-info-block__content_p">
          <span class="owners-info-block__content_span-type">Тип владельца: </span>
          <span class="owners-info-block__content_span-value">{{owner.type}}</span>
        </p>
        <p class="owners-info-block__content_p">
          <span class="owners-info-block__content_span-type">Регион регистрации: </span>
          <span class="owners-info-block__content_span-value">{{owner.regionRegistration}}</span>
        </p>
        <p class="owners-info-block__content_p" v-if="!!owner.organisationName">
          <span class="owners-info-block__content_span-type">Название организации: </span>
          <span class="owners-info-block__content_span-value">{{owner.organisationName}}</span>
        </p>
      </div>
    </div>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock"
import {Owner} from "@/models/Owner";
import { ref, watch } from "vue";

interface Props {
  owners: Owner[]
}

const props = defineProps<Props>()
const header = ref('');

watch(props.owners, () => {
  let str = ''
  const ownerCount = props.owners.length
  const ownerCountRemain = ownerCount % 10;

  if(ownerCount === 1 || ownerCountRemain === 1)
    str = 'владелец'
  else if((ownerCount > 1 && ownerCount < 5) || (ownerCountRemain > 1 && ownerCountRemain < 5))
    str = 'владельца'
  else
    str = 'владельцов'

  header.value = `${ownerCount} ${str} по ПТС`
})

</script>

<style lang="scss" scoped>

.owners-info-block__content:not(.owners-info-block__content:last-child) {
  border-bottom: 1px solid  #e0e0e0;
}

.owners-info-block__content_span-type {
  color: #858585;
}

</style>