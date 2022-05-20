<template>
  <info-block :header="header">
    <div class="owners-info-block__container">
      <div class="owners-info-block__content" v-for="(owner, i) in props.owners" :key="owner.ownershipPeriod">
        <p><b>{{i + 1}} владелец</b></p>
        <p class="owners-info-block__content_p" v-for="(propVal, propName) in owner" :key="propName">
          <span class="owners-info-block__content_span-type">
            {{ruOwnerProps[propName]}}:
          </span>
          <span class="owners-info-block__content_span-value">
            {{propVal}}
          </span>
        </p>
      </div>
    </div>
  </info-block>
</template>

<script lang="ts" setup>
import InfoBlock from "@/components/InfoBlock"
import {Owner} from "@/models/Owner";

interface Props {
  owners: Owner[]
}

const ruOwnerProps = {
  ownershipPeriod: "Период владения",
  ownershipDuration: "Срок сладения",
  type: "Тип владельца",
  regionRegistration: "Регион регистрации",
  organisationName: "Названии организации"
}

const props = defineProps<Props>()

const header = `${props.owners.length} владелец по ПТС`;
</script>

<style lang="scss" scoped>

.owners-info-block__content:not(.owners-info-block__content:last-child) {
  border-bottom: 1px solid  #e0e0e0;
}

.owners-info-block__content_span-type {
  color: #858585;
}

</style>