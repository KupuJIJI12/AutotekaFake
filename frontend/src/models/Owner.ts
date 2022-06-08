export type Owner = {
    ownershipPeriod: Date,
    ownershipDuration: Date,
    type: OwnerType | string,
    regionRegistration: string,
    organisationName?: string
}

export enum OwnerType {
    LegalPerson,
    NaturalPerson
}