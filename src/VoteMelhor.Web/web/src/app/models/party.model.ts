import { PoliticalParty } from './political-party.model';

export interface Party {
  name: string;
  initials: string;
  number: number;
  image: string;
  politicalPartys: PoliticalParty[];
  id: string;
}
