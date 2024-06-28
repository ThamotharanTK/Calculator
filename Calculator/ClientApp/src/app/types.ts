export interface EvaluateResult {
    Succeeded: boolean;
    Result: number;
    ErrorMessage: string;
}
export interface User {
    Email: string;
    AccessToken: string;
    RefreshToken: string;
}
export interface CalculatorHistory {
    Id: number;
    Succeeded: boolean;
    ErrorMessage: string;
    Input: string;
    Result: number;
    EvaluateAt: Date;
}