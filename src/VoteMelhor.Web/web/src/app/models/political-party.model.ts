import { Party } from './party.model';

export interface PoliticalParty {
  current: boolean;
  politicalId: string;
  partyId: string;
  party: Party;
  id: string;
}
