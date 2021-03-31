export interface OrderInterface {
  id: number;
  date: string;
  time: number;
  prepTime: number;
  state: string;
  dishes: number[];
  chef: string;
  client: number;
  feedbackTime: string;
  feedbackScore: string;
}
