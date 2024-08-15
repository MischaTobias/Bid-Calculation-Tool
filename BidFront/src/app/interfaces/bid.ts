import { Fee } from "./fee";

export interface Bid {
  total: number;
  fees: Fee[];
}
