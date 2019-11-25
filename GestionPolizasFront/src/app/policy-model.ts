export class PolicyModel {
    constructor() {}

    public id: number;
    public name: string;
    public description: string;
    public policyTypeId: number;
    public coverage: number;
    public price: number;
    public riskTypeId: number;
    public active: boolean;
}
