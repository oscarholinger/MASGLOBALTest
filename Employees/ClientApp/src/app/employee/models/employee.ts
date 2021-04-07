export class Employee {
  constructor(
    public id: number,
    public name: string,
    public contractTypeName: string,
    public roleId: number,
    public roleName: string,
    public roleDescription: string,
    public hourlySalary: number,
    public monthlySalary: number,
    public anualSalary: number,
  ) { }
}
