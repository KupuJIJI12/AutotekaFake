export type Crash = {
    date: Date,
    type: string,
    vehicleCondition: string
    damaged: Damage[]
}

export type Damage = {
    type: string,
    region: string,
    description?: string
}