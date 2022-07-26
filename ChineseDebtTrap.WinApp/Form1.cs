using ChineseDebtTrap.Repository;
using ChineseDebtTrap.Core;

namespace ChineseDebtTrap.WinApp
{
    public partial class Form1 : Form
    {
        private readonly LenderRepository _lenderRepository;
        private readonly BorpowerRepository _borpowerRepository;
        private readonly SectorRepository _sectorRepository;
        private readonly SensitiveTerritoryRepository _sensitiveTerritoryRepository;
        private readonly CountryRepository _countryRepository;

        public Form1()
        {
            InitializeComponent();
            _lenderRepository = new LenderRepository();
            _borpowerRepository = new BorpowerRepository();
            _sectorRepository = new SectorRepository();
            _sensitiveTerritoryRepository = new SensitiveTerritoryRepository();
            _countryRepository = new CountryRepository();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateLenderList();
            UpdateBorpowerList();
            UpdateSectorList();
            UpdateSensitiveList();
            UpdateCountryList();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _lenderRepository.Add(new Lender() { Name = textBoxLender.Text });
            UpdateLenderList();
            textBoxLender.Clear();
        }

        private void buttonAddBorpower_Click(object sender, EventArgs e)
        {
            _borpowerRepository.Add(new Borpower() { Name = textBoxBorpower.Text });
            UpdateBorpowerList();
            textBoxBorpower.Clear();
        }

        private void buttonAddSector_Click(object sender, EventArgs e)
        {
            _sectorRepository.Add(new Sector() { Name = textBoxSector.Text });
            UpdateSectorList();
            textBoxSector.Clear();
        }

        private void buttonAddSensitive_Click(object sender, EventArgs e)
        {
            _sensitiveTerritoryRepository.Add(new SensitiveTerritory() { Name = textBoxSensitive.Text });
            UpdateSensitiveList();
            textBoxSensitive.Clear();
        }

        private void buttonAddCountry_Click(object sender, EventArgs e)
        {
            _countryRepository.Add(new Country() { Name = textBoxCountry.Text });
            UpdateCountryList();
            textBoxCountry.Clear();
        }

        private void UpdateLenderList()
        {
            listBoxLender.Items.Clear();
            listBoxLender.Items.AddRange(_lenderRepository.GetAll().ToArray());
        }

        private void UpdateBorpowerList()
        {
            listBoxBorpower.Items.Clear();
            listBoxBorpower.Items.AddRange(_borpowerRepository.GetAll().ToArray());
        }

        private void UpdateSectorList()
        {
            listBoxSector.Items.Clear();
            listBoxSector.Items.AddRange(_sectorRepository.GetAll().ToArray());
        }

        private void UpdateSensitiveList()
        {
            listBoxSensitive.Items.Clear();
            listBoxSensitive.Items.AddRange(_sensitiveTerritoryRepository.GetAll().ToArray());
        }

        private void UpdateCountryList()
        {
            listBoxCountry.Items.Clear();
            listBoxCountry.Items.AddRange(_countryRepository.GetAll().ToArray());
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listBoxLender.SelectedItems.Count > 0)
            {
                foreach(var selected in listBoxLender.SelectedItems)
                {
                    var lender = selected as Lender;

                    if (_lenderRepository.AnyCompanies(lender.Id))
                    {
                        MessageBox.Show($"Перірьте наявність зв'язанх об'єктів з {lender.Name}");
                    }
                    else
                    {
                        _lenderRepository.Remove(lender.Id);
                    }      
                }
                UpdateLenderList();
            }
        }

        private void buttonRemoveBorpower_Click(object sender, EventArgs e)
        {
            if (listBoxBorpower.SelectedItems.Count > 0)
            {
                foreach(var selected in listBoxBorpower.SelectedItems)
                {
                    var borpower = selected as Borpower;

                    if (_borpowerRepository.AnyCompanies(borpower.Id))
                    {
                        MessageBox.Show($"Перірьте наявність зв'язанх об'єктів з {borpower.Name}");
                    }
                    else
                    {
                        _borpowerRepository.Remove(borpower.Id);
                    }
                }
                UpdateBorpowerList();
            }
        }

        private void buttonRemoveSector_Click(object sender, EventArgs e)
        {
            if (listBoxSector.SelectedItems.Count > 0)
            {
                foreach (var selected in listBoxSector.SelectedItems)
                {
                    var sector = selected as Sector;

                    if (_borpowerRepository.AnyCompanies(sector.Id))
                    {
                        MessageBox.Show($"Перірьте наявність зв'язанх об'єктів з {sector.Name}");
                    }
                    else
                    {
                        _borpowerRepository.Remove(sector.Id);
                    }
                }
                UpdateSectorList();
            }
        }

        private void buttonRemoveSensitive_Click(object sender, EventArgs e)
        {
            if (listBoxSensitive.SelectedItems.Count > 0)
            {
                foreach (var selected in listBoxSensitive.SelectedItems)
                {
                    var sensitive = selected as SensitiveTerritory;

                    if (_sensitiveTerritoryRepository.AnyCompanies(sensitive.Id))
                    {
                        MessageBox.Show($"Перірьте наявність зв'язанх об'єктів з {sensitive.Name}");
                    }
                    else
                    {
                        _sensitiveTerritoryRepository.Remove(sensitive.Id);
                    }
                }
                UpdateSensitiveList();
            }
        }

        private void buttonRemoveCountry_Click(object sender, EventArgs e)
        {
            if (listBoxCountry.SelectedItems.Count > 0)
            {
                foreach (var selected in listBoxCountry.SelectedItems)
                {
                    var country = selected as Country;

                    if (_countryRepository.AnyCompanies(country.Id))
                    {
                        MessageBox.Show($"Перірьте наявність зв'язанх об'єктів з {country.Name}");
                    }
                    else
                    {
                        _countryRepository.Remove(country.Id);
                    }
                }
                UpdateCountryList();
            }
        }
    }
}