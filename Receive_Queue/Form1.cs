using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apache.NMS;
using Apache.NMS.Util;
using Apache.NMS.ActiveMQ;
using OperatorRequestOject;
using Apache.NMS.ActiveMQ.Commands;

namespace Receive_Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reciver();
        }
        void reciver()
        {
            IConnectionFactory factory = new NMSConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            //IDestination destination = SessionUtil.GetDestination(session, "Example Queue");
            //IDestination destination = SessionUtil.GetDestination(session, "Ex ActiveMQQueue");
            ActiveMQQueue destination = new ActiveMQQueue("Ex ActiveMQQueue");
            IMessageConsumer receiver = session.CreateConsumer(destination);
            //richTextBox1.Text = receiver.ToString();
            //receiver.Listener += new MessageListener(NoiDungNhan);
            IMessage mes = receiver.Receive();
            ActiveMQTextMessage x = mes as ActiveMQTextMessage;
            richTextBox1.Text = x.Text;
        }
        void NoiDungNhan(IMessage mes)
        {
            IObjectMessage objRe = mes as IObjectMessage;
            //richTextBox1.Text += objRe.Body.ToString(); 
            //OperatorRequestObject ReObj = ((OperatorRequestOject.OperatorRequestObject)(objRe.Body));
            //string txt = "start  ";
            //   txt += ReObj.ShortCode + "\n";
            //richTextBox1.Text = txt;
            MessageBox.Show(objRe.Body.ToString());
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
