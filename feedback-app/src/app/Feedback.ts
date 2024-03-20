export interface Feedback{
    id: number;
    title: string;
    description: string;
    authorId: number;
    author: {
      id: number;
      fullName: string;
    };
}