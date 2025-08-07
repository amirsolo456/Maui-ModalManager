using ModalManager.Controls;
using ModalManager.Services;

namespace ModalManagerSample
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        private readonly IModalService _modalService;
 
        public MainPage(IModalService modalService)
        {
            InitializeComponent();

            _modalService = modalService;
            (_modalService as ModalService)?.RegisterHost(ModalHost);
        }

        private void OnShowModalClicked(object sender, EventArgs e)
        {
            _modalService.ShowCenteredLabel("سلام! این یک مودال تستی است.");
        }


        private void OnShowTwiceModalClicked(object sender, EventArgs e)
        {
            var openSecondModalButton = new Button
            {
                Text = "باز کردن مودال دوم",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 20, 0, 0)
            };

            var firstModalContent = new StackLayout
            {
                Children =
                    {
                        new Label
                        {
                            Text = "این مودال اول است.",
                            FontSize = 18,
                            HorizontalOptions = LayoutOptions.Center
                        },
                        openSecondModalButton
                    }
            };

           var modalView = new ModalView(Content);
            modalView.OnClosed += () => _modalService.CloseCurrent();

            // نمایش مودال اول
            _modalService.Show(modalView);

            // وقتی روی دکمه کلیک شد مودال دوم نمایش داده شود
            openSecondModalButton.Clicked += (s, args) =>
            {
                var secondModalContent = new StackLayout
                {
                    Children =
            {
                new Label
                {
                    Text = "این مودال دوم است.",
                    FontSize = 18,
                    HorizontalOptions = LayoutOptions.Center
                },
                new Button
                {
                    Text = "بستن مودال دوم",
                    HorizontalOptions = LayoutOptions.Center,
                    Command = new Command(() => _modalService.CloseCurrent())
                }
            }
                };

                var secondModal = new ModalView(secondModalContent);
 

                secondModal.OnClosed += () => _modalService.CloseCurrent();

                _modalService.Show(secondModal);
            };
        }


    }
}
 
 

