export interface DishInterface {
  id: number;
  name: string;
  description: string;
  price: number;
  amountSales: number;
  ingredients: Array<string>;
  prepTime: number;
}
