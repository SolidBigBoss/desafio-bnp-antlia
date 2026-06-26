import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProdutoService } from '../../services/produto.service';
import { MovimentoService } from '../../services/movimento.service';
import { Produto } from '../../models/produto.model';
import { ProdutoCosif } from '../../models/produto-cosif.model';
import { MovimentoLista } from '../../models/movimento-lista.model';
import { MovimentoCreate } from '../../models/movimento-create.model';

@Component({
  selector: 'app-movimentos',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './movimentos.html',
  styleUrl: './movimentos.css'
})
export class Movimentos implements OnInit {
  produtos: Produto[] = [];
  cosifs: ProdutoCosif[] = [];
  movimentos: MovimentoLista[] = [];

  camposHabilitados = false;

  mes: number | null = null;
  ano: number | null = null;
  idProduto: string = '';
  idCosif: string = '';
  valor: number | null = null;
  descricao: string = '';

  constructor(
    private produtoService: ProdutoService,
    private movimentoService: MovimentoService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.carregarProdutos();
    this.carregarMovimentos();
  }

  carregarProdutos(): void {
    this.produtoService.listarProdutos().subscribe({
      next: (data) => {
        this.produtos = data;
        this.cdr.markForCheck();
      },
      error: (err) => console.error('Erro ao carregar produtos', err)
    });
  }

  carregarMovimentos(): void {
    this.movimentoService.listarMovimentos().subscribe({
      next: (data) => {
        this.movimentos = data;
        this.cdr.markForCheck();
      },
      error: (err) => console.error('Erro ao carregar movimentos', err)
    });
  }

  onProdutoChange(): void {
    this.idCosif = '';
    this.cosifs = [];

    if (!this.idProduto) {
      return;
    }

    this.produtoService.listarCosifsPorProduto(this.idProduto).subscribe({
      next: (data) => {
        this.cosifs = data;
        this.cdr.markForCheck();
      },
      error: (err) => console.error('Erro ao carregar cosifs', err)
    });
  }

  novo(): void {
    this.camposHabilitados = true;
    this.limpar();
  }

  limpar(): void {
    this.mes = null;
    this.ano = null;
    this.idProduto = '';
    this.idCosif = '';
    this.valor = null;
    this.descricao = '';
    this.cosifs = [];
  }

  incluir(): void {
    if (!this.mes || !this.ano || !this.idProduto || !this.idCosif || this.valor === null || !this.descricao) {
      alert('Preencha todos os campos antes de incluir.');
      return;
    }

    const novoMovimento: MovimentoCreate = {
      mes: this.mes,
      ano: this.ano,
      idProduto: this.idProduto,
      idCosif: this.idCosif,
      valor: this.valor,
      descricao: this.descricao
    };

    this.movimentoService.incluirMovimento(novoMovimento).subscribe({
      next: () => {
        this.carregarMovimentos();
        this.limpar();
        this.camposHabilitados = false;
        this.cdr.markForCheck();
      },
      error: (err) => console.error('Erro ao incluir movimento', err)
    });
  }
}