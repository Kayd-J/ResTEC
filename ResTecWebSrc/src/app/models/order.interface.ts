export interface OrderInterface {
  id: number;
  date: string;
  time: number;
  prepTime: number;
  state: string;
  dishes: Array<number>;
  chef: string;
}
