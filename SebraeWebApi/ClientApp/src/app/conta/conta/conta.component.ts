import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ContaService } from 'src/app/services/conta.service';

@Component({
  selector: 'app-conta',
  templateUrl: './conta.component.html'
})
export class ContaComponent implements OnInit {
  constructor(private fb: FormBuilder,
    private contaService: ContaService
    , private modalService: BsModalService

  ) { }

  contas: any[];
  registerForm: FormGroup;
  modalRef: BsModalRef;
  contaId: number;
  ngOnInit() {
    this.validation();
    this. get();
  }

  validation() {
    this.registerForm = this.fb.group({
      contaId: [],
      nome: ['', Validators.required],
      descricao: ['']
    });
  }

  get() {
    this.contaService.get().subscribe(
      (_contas: any) => {
       this.contas = _contas;
        console.log(_contas);
      }, error => {
        console.log(`Erro ao tentar Carregar: ${error}`)
      });
  }

  openModal(template: TemplateRef<any>, contaId: any){
    this.contaId = contaId;
    this.modalRef = this.modalService.show(template);
  }

  deletar(){
    this.contaService.delete(this.contaId).subscribe(
      () => {
        this.modalRef.hide();
        this.get();
        // this.toastr.success('Deletado Sucesso!');
      }, error => {
        // this.toastr.error(`Erro: ${error}`);
      }
      );
  }
}
