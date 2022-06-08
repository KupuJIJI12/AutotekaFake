export type Crash = {
    date: Date | string,
    type: string,
    vehicleCondition: string
    damaged: Damage[]
}

export type Damage = {
    type: string,
    region: string,
    description?: string
}