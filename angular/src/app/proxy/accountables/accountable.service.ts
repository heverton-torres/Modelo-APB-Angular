import type { AccountableDto, CreateAccountableDto, GetAccountableListDto, UpdateAccountableDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AccountableService {
  apiName = 'Default';
  

  create = (input: CreateAccountableDto) =>
    this.restService.request<any, AccountableDto>({
      method: 'POST',
      url: '/api/app/accountable',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/accountable/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, AccountableDto>({
      method: 'GET',
      url: `/api/app/accountable/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: GetAccountableListDto) =>
    this.restService.request<any, PagedResultDto<AccountableDto>>({
      method: 'GET',
      url: '/api/app/accountable',
      params: { filter: input.filter, sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: UpdateAccountableDto) =>
    this.restService.request<any, void>({
      method: 'PUT',
      url: `/api/app/accountable/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
