using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Network;
using Server.Misc;

namespace GeNova.Server.Engines
{
    public class StatusLogin
    {
        public static readonly bool Ativo = true;

        public static void Initialize()
        {
            EventSink.Login += new LoginEventHandler(EventSink_Login);
        }

        private static void EventSink_Login(LoginEventArgs args)
        {
            int usuariosOnline = NetState.Instances.Count;
            int totalItems = World.Items.Count;
            int totalMobiles = World.Mobiles.Count;

            Mobile jogador = args.Mobile;
            StringBuilder mensagem = new StringBuilder();
            mensagem.AppendFormat("Bem vindo, {0}! ", jogador.Name);
            mensagem.AppendFormat("Voc� est� conectado a {0} - A Nova Gera��o! ", ServerList.ServerName);
            mensagem.AppendFormat("- Existem atualmente {0} usu�rios online, ", usuariosOnline);
            mensagem.AppendFormat("temos {0} itens ", totalItems);
            mensagem.AppendFormat("e {0} m�veis no mundo.", totalMobiles);
            jogador.SendMessage(mensagem.ToString());

            PersonagemDesconhecido.VerificarComRestricoes(jogador);
            PersonagemEmMundoRestrito.VerificarComRestricoes(jogador);
            PersonagemIniciante.VerificarComRestricoes(jogador);
        }
    }
}
