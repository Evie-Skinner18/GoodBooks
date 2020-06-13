// this should match directly to C# view model/DTO
export default interface IBook {
    id: number;
    title: string;
    author: string;
    createdOn: Date;
    updatedOn: Date;
}