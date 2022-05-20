export type Owner = {
    ownershipPeriod: Date,
    ownershipDuration: Date,
    type: OwnerType,
    regionRegistration: string,
    organisationName?: string
}

export enum OwnerType {
    LegalPerson,
    NaturalPerson
}