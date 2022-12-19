function tableButtons(id) {
    return `<div class="btn-group">
                        <button class="btn btn-primary edit" value="${id}" title="Edit">

                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>

                        </button>

                        <button class="btn btn-success details" value="${id}" title="Details">

                            <i class="fa fa-bars" aria-hidden="true"></i>

                        </button>

                        <button class="btn btn-danger delete" value="${id}" title="Delete">

                            <i class="fa fa-trash" aria-hidden="true" title="Delete"></i>

                        </button>

                   </div>`;

}