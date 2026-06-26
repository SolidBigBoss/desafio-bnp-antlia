export interface MovimentoCreate {
  mes: number;
  ano: number;
  idProduto: string;
  idCosif: string;
  valor: number;
  descricao: string;
}