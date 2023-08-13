import { Miasto } from "src/app/Miasto/Models/miasto.model";

export interface Parking{

    id: number;
    nazwa: string;
    adres: string;
    liczbaMiejsc: number;
    liczbamiejscinwalidzkich?: number;
}