import { Fee } from "./fee";

export interface Bid {
  total: Number;
  fees: Fee[];
}
