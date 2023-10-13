import {Province} from "./province";

export interface Country {
  countryId: string;
  name: string;
  provinces?: Province[];
}
