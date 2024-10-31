


namespace MALO.Microservice.Empleosdb.Aplication.Presenters
{
    public class MultimediaPresenter : IMultimediaPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public MultimediaPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public async Task<List<MultimediaDto>> GetMultimedia()
        {
            return await _unitRepository.multimediaInfraestructure.GetMultimedia();
        }
        public async Task<MultimediaDto> GetMultimediaById([FromBody] MultimediaIdDto request)
        {
            return await _unitRepository.multimediaInfraestructure.GetMultimediaById(request);
        }
        public async Task<string> PostMultimedia([FromBody] MultimediaPostDto request)
        {
            return await _unitRepository.multimediaInfraestructure.PostMultimedia(request);
        }
        public async Task<string> UpdateMultimediaById([FromBody] MultimediaUpdateDto request)
        {
            return await _unitRepository.multimediaInfraestructure.UpdateMultimediaById(request);
        }
        public async Task<string> DeleteMultimediaById([FromBody] MultimediaIdDto request)
        {
            return await _unitRepository.multimediaInfraestructure.DeleteMultimediaById(request);
        }
    }
}
