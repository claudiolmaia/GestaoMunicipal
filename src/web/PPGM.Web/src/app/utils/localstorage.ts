export class LocalStorageUtils {
    
    public obterUsuario() {
        return JSON.parse(localStorage.getItem('ppgm.user'));
    }

    public salvarDadosLocaisUsuario(response: any) {
        this.salvarTokenUsuario(response.accessToken);
        this.salvarUsuario(response.usuarioToken);
        this.salvarRefreshToken(response.refreshToken);
    }

    public limparDadosLocaisUsuario() {
        localStorage.removeItem('ppgm.token');
        localStorage.removeItem('ppgm.rt');
        localStorage.removeItem('ppgm.user');
    }

    public obterTokenUsuario(): string {
        return localStorage.getItem('ppgm.token');
    }

    public obterRefreshTokenUsuario(): string {
        return localStorage.getItem('ppgm.rt');
    }

    public salvarTokenUsuario(token: string) {
        localStorage.setItem('ppgm.token', token);        
    }

    public salvarUsuario(user: string) {
        localStorage.setItem('ppgm.user', JSON.stringify(user));
    }

    public salvarRefreshToken(rt: string) {
        localStorage.setItem('ppgm.rt', JSON.stringify(rt));
    }

}