import { PositionC } from './positionC.model';
import { PoliticalParty } from './political-party.model';
import { Rating } from './rating.model';
import { LawSuit } from './lawsuit.model';
import { Voting } from './voting.model';

export interface Political {
  congressmanId: number;
  senatorId: number;
  name: string;
  fullName: string;
  state: string;
  image: string;
  politicalPartys: PoliticalParty[];
  ratings?: Rating[];
  lawSuits?: LawSuit[];
  votings?: Voting[];
  positions: PositionC[];
  id: string;
}













