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
using Apache.NMS.ActiveMQ.Util;
using Apache.NMS.ActiveMQ.Commands;
using Apache.NMS.ActiveMQ.Transactions;
using OperatorRequestOject;
using System.IO;

namespace Example_Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            //IObjectMessage objMes;
            //OperatorRequestObject OperatorRequestObject = new OperatorRequestObject();
            //OperatorRequestObject.ShortCode = txt.Text.ToString();

            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection();
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            //IDestination QueueDestination = SessionUtil.GetDestination(session, "Example Queue");
            ActiveMQQueue QueueDestination = new ActiveMQQueue("Ex ActiveMQQueue");//ActiveMQQueue don gian hon IDestination
            IMessageProducer MessageProducer = session.CreateProducer(QueueDestination);
            //objMes = session.CreateObjectMessage(txt.Text.ToString());

            MessageProducer.Send(session.CreateTextMessage(txt.Text.ToString()));
            session.Close();
            connection.Stop();
        }
    }
}
