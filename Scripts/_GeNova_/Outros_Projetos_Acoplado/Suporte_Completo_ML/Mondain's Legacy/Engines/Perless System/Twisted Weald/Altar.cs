using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	public class TwistedWealdAltar : PeerlessAltar
	{		
		public override int KeyCount{ get{ return 3; } }
		public override MasterKey MasterKey{ get{ return new TwistedWealdKey(); } }
		
		public override Type[] Keys{ get{ return new Type[]
		{
			typeof( BlightedCotton ), typeof( GnawsFang ), typeof( IrksBrain ), 
			typeof( LissithsSilk ), typeof( SabrixsEye ), typeof( ThornyBriar )
		}; }}
		
		public override BasePeerless Boss{ get{ return new DreadHorn(); } }		
			
		[Constructable]
		public TwistedWealdAltar() : base( 0x207C )
		{			
			BossLocation = new Point3D( 2137, 1247, -60 );
			TeleportDest = new Point3D( 2151, 1261, -60 );
			ExitDest = new Point3D( 1448, 1537, -28 );
		}
	
		public TwistedWealdAltar( Serial serial ) : base( serial )
		{
		}	
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}