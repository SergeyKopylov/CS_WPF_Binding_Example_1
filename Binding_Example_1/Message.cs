using System.ComponentModel;

namespace Binding_Example_1
{
    public class Message : INotifyPropertyChanged
    {
        private string _message;

        public Message()
        {
        }

        public Message(string message)
        {
            _message = message;
        }

        public string MessageText
        {
            get { return _message; }
            set
            {
                _message = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(MessageText));
            }
        }
        

        private string _clientsCnt;
        public string ClientsCnt
        {
            get { return _clientsCnt; }
            set
            {
                _clientsCnt = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(ClientsCnt));
            }
        }


        private string _txtBox1;
        public string TxtBox1
        {
            get { return _txtBox1; }
            set
            {
                _txtBox1 = value;
                _txtBox2 = _txtBox1;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(TxtBox1));
                OnPropertyChanged(nameof(TxtBox2));
            }
        }


        private string _txtBox2;
        public string TxtBox2
        {
            get { return _txtBox2; }
            set
            {
                _txtBox2 = value;
                _txtBox1 = _txtBox2;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged(nameof(TxtBox2));
                OnPropertyChanged(nameof(TxtBox1));
            }
        }


        // Declare the event
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
