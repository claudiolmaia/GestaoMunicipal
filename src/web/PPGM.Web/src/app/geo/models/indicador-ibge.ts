
export interface Unidade {
    id: string;
    classe: string;
    multiplicador: number;
}

export interface Res {
    2006: string;
    2007: string;
    2008: string;
    2009: string;
    2010: string;
    2011: string;
    2012: string;
    2013: string;
    2014: string;
    2015: string;
    2016: string;
    2017: string;
    2018: string;
    2019: string;
    2020: string;
    2021: string;
}

export interface Notas {
    2006?: any;
    2007?: any;
    2008?: any;
    2009?: any;
    2010?: any;
    2011?: any;
    2012?: any;
    2013?: any;
    2014?: any;
    2015?: any;
    2016?: any;
    2017?: any;
    2018?: any;
    2019?: any;
    2020?: any;
    2021?: any;
}

export interface Re {
    localidade: string;
    res: Res;
    notas: Notas;
}

export interface IndicadorIbge {
    id: number;
    pesquisa_id: number;
    posicao: string;
    indicador: string;
    classe: string;
    unidade: Unidade;
    children: any[];
    res: Re[];
}



