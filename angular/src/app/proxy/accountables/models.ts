import type { EntityDto, PagedAndSortedResultRequestDto } from '@abp/ng.core';
import type { AccountablePosition } from './accountable-position.enum';

export interface AccountableDto extends EntityDto<string> {
  name?: string;
  birthDate?: string;
  position: AccountablePosition;
}

export interface CreateAccountableDto {
  name: string;
  birthDate: string;
  position: AccountablePosition;
}

export interface GetAccountableListDto extends PagedAndSortedResultRequestDto {
  filter?: string;
}

export interface UpdateAccountableDto {
  name: string;
  birthDate: string;
  position: AccountablePosition;
}
