import { mapEnumToOptions } from '@abp/ng.core';

export enum AccountablePosition {
  Undefined = 0,
  TeamMember = 1,
  Techlead = 2,
  Teamlead = 3,
}

export const accountablePositionOptions = mapEnumToOptions(AccountablePosition);
