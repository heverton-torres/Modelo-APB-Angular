import { isNullOrEmpty, ListService, PagedResultDto } from '@abp/ng.core';
import { ConfirmationService,Confirmation } from '@abp/ng.theme.shared';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { AccountableDto, AccountablePosition, accountablePositionOptions, AccountableService } from '@proxy/accountables';

@Component({
  selector: 'app-accountable',
  templateUrl: './accountable.component.html',
  styleUrls: ['./accountable.component.scss'],
  providers:[ListService,{
    provide:NgbDateAdapter,useClass: NgbDateNativeAdapter
  }]
})
export class AccountableComponent implements OnInit {

  accountable ={items:[], totalCount:0} as PagedResultDto<AccountableDto>;

  accountablePositions= accountablePositionOptions;
  isModalOpen =false;
  form: FormGroup;

  selectAccountable= {} as AccountableDto;

  constructor(public readonly list:ListService,
    private accountableService:AccountableService,
    private fb:FormBuilder,
    private confirmation:ConfirmationService) {}

  ngOnInit(): void {
    const accountableStreamCreator = (query)=> this.accountableService.getList(query);
    this.list.hookToQuery(accountableStreamCreator).subscribe((response)=>{
      this.accountable= response;
    })
  }

  createAccoutable(){
    this.selectAccountable ={} as AccountableDto;
    this.buildForm();
    this.isModalOpen=true;
  }
  editAccoutable(id:string){
    this.accountableService.get(id).subscribe((accoutable)=>{
      this.selectAccountable =accoutable;
      this.buildForm();
      this.isModalOpen=true;
    });
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.accountableService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }

  buildForm(){
    this.form = this.fb.group({
      name:[this.selectAccountable.name || '', Validators.required],
      birthDate:[
        this.selectAccountable.birthDate? new Date(this.selectAccountable.birthDate): null,
        Validators.required,
      ],
       position:[this.selectAccountable.position || null]
    });
  }
  position(id){
    return AccountablePosition[id];
  }
  save(){
    if (this.form.invalid) {
      return;
    }

    if (this.selectAccountable.id) {
      this.accountableService
        .update(this.selectAccountable.id,this.form.value)
        .subscribe(()=>{
          this.isModalOpen=false;
          this.form.reset();
          this.list.get();
        })
    } else {
      this.accountableService.create(this.form.value).subscribe(()=>{
        this.isModalOpen=false;
        this.form.reset();
        this.list.get();
      })

    }
  }
}
